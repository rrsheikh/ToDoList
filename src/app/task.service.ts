import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
readonly apiUrl = "https://localhost:44318/api/Checklist/";
  constructor(private http:HttpClient) { }

  getTasks():Observable<any[]>{
    return this.http.get<any>(this.apiUrl + "GetChecklist");
  }
}
