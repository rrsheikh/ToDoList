import { Component, OnInit } from '@angular/core';
import { TaskService } from '../task.service';
import { UserTask } from './usertask';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  constructor(private service:TaskService) { }

  Checklist:UserTask[] = [];// = [{description : 'test', completed : true}];
  completedTasks:UserTask[];
  pendingTasks:UserTask[];
  newTask:UserTask = new UserTask;

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
    this.completedTasks = [];
    this.pendingTasks = [];
    this.Checklist.forEach(task => { task.completed ? this.completedTasks.push(task) : this.pendingTasks.push(task) });
  }

  AddTask(newTask: any){
    this.newTask = {description: newTask, completed:false};
    this.service.addTask(this.newTask).subscribe(response => {
      this.getChecklist();
    });
  }

}
