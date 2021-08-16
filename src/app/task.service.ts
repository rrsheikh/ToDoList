import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserTask } from './tasks/usertask';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
readonly apiUrl = "https://localhost:44318/api/Checklist/";
  constructor(private http:HttpClient) { }

  getTasks():Observable<any[]>{
    return this.http.get<any>(this.apiUrl + "GetChecklist");
  }

  addTask(task:UserTask){
    return this.http.post(this.apiUrl + "AddTask", task);
  }
}
