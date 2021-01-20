import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { environment } from '../../../environments/environment';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Task } from '../models/task';

const API_URL = environment.taskApiUrl;
@Injectable()
export class TaskService {

  constructor(private http: Http) { }

  public getUserTasks(userId): Observable<Task[]> {
    return this.http
      .get(API_URL + '/api/task?userId='+ userId)
      .map(response => {
        const tasksResponse = response.json();
        return tasksResponse.data.map((task) => new Task(task));
      })
      .catch(this.handleError);
  }

  public createTask(task: Task): Observable<Task> {
    return this.http
      .post(API_URL + '/api/task', task)
      .map(response => {
        const taskResponse = response.json();
        return new Task(taskResponse.data);
      })
      .catch(this.handleError);
  }

  public updateTask(task: Task): Observable<Task> {
    return this.http
      .put(API_URL + '/api/task/' + task.id, task)
      .map(response => {
        const taskResponse = response.json();
        return new Task(taskResponse.data);
      })
      .catch(this.handleError);
  }

  public deleteUserTasks(userId): Observable<Task[]> {
    return this.http
      .delete(API_URL + '/api/task?userId='+ userId)
      .map(response => null)
      .catch(this.handleError);
  }
  // public deleteUserById(userId: number): Observable<null> {
  //   return this.http
  //     .delete(API_URL + '/todos/' + userId)
  //     .map(response => null)
  //     .catch(this.handleError);
  // }

  private handleError (error: Response | any) {
    console.error('ApiService::handleError', error);
    return Observable.throw(error);
  }

}
