import { Component, OnInit } from '@angular/core';
import { TaskService } from '../task.service';
import { Tasks } from './tasks';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  constructor(private service:TaskService) { }

  Checklist:Tasks[] = [];// = [{description : 'test', completed : true}];
  completedTasks:Tasks[] = [];
  pendingTasks:Tasks[] = [];

  ngOnInit(): void {
    this.getChecklist();
  }
  
  getChecklist(){
    
    this.service.getTasks().subscribe(
      data =>{
        this.Checklist = data;
        this.groupTasks();
      }
    )
    
  }

  groupTasks(){
    this.Checklist.forEach(task => { task.completed ? this.completedTasks.push(task) : this.pendingTasks.push(task) });
  }

}
