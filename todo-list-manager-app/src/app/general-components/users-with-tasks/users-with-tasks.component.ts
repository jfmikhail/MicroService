import { Component, OnInit } from '@angular/core';
import { User } from '../../users/models/user';
import { Task } from '../../tasks/models/task';
import { UserService } from '../../users/services/user.service';
import { TaskService } from '../../tasks/services/task.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-users-with-tasks',
  templateUrl: './users-with-tasks.component.html',
  styleUrls: ['./users-with-tasks.component.css']
})
export class UsersWithTasksComponent implements OnInit {

  users: User[] = [];
  tasks: Task[] = [];

  constructor(
    private userDataService: UserService,
    private taskDataService: TaskService,
    private route: ActivatedRoute
  ) {
  }

  selectedUser:User;
  public ngOnInit() {
    this.userDataService
    .getAllUsers()
    .subscribe(
      (users)=> {
        this.users = users;
        if(users.length>0)
          this.getUserTasks(users[0]);
      }
    )
  }

  addUiTask(){
    this.tasks = this.tasks.concat([new Task()]);
  }

  public getUserTasks(user){
    this.selectedUser = user;
    this.taskDataService
          .getUserTasks(user.id)
            .subscribe(
              (tasks)=> {
                this.tasks = tasks
                if(this.tasks.length == 0){
                  this.addUiTask();
                }
              });
  }

  onToggleTaskDone(task:Task) {
    if(task.state == "done")
        task.state = "todo";
    else
      task.state = "done";

    this.updateTask(task);
  }

  saveOrUpdateTask(task:Task){
    if(!task.id || task.id<=0){
      this.onAddTask(task);
    }else{
      this.updateTask(task);
    }
  }

  updateTask(task:Task){
    this.taskDataService
      .updateTask(task)
      .subscribe(
        (updatedTask) => {
          task = updatedTask;
        }
      );
  }

  onAddTask(task:Task) {
    if(!this.selectedUser)
      return
    task.userId = this.selectedUser.id;

    this.taskDataService
      .createTask(task)
      .subscribe(
        (newTask) => {
          task.id = newTask.id;
          // this.tasks = this.tasks.concat(newTask);
        }
      );
  }

  

  onUpdateUser(user){
    this.userDataService
    .updateUser(user)
    .subscribe(
      (updatedUser)=>{
        user = updatedUser;
      }
    )
  }
  onRemoveUser(user) {
    this.userDataService
      .deleteUserById(user.id)
      .subscribe(
        (_) => {
          this.users = this.users.filter((t) => t.id !== user.id);
          this.taskDataService.deleteUserTasks(user.id)
          .subscribe((_)=>{
            if(this.selectedUser.id == user.id){
              if(this.users.length>0)
                this.getUserTasks(this.users[0]);
              else
                this.tasks=[];
            }
          });
        }
      );
  }

}
