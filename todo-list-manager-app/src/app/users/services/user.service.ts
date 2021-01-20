import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { User } from '../models/user';
import { environment } from '../../../environments/environment';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const API_URL = environment.apiUrl;

@Injectable()
export class UserService {

  constructor(private http: Http) { }

  public getAllUsers(): Observable<User[]> {
    return this.http
      .get(API_URL + '/api/user')
      .map(response => {
        const usersResponse = response.json();
        return usersResponse.data.map((user) => new User(user));
      })
      .catch(this.handleError);
  }

  // public createUser(todo: Todo): Observable<Todo> {
  //   return this.http
  //     .post(API_URL + '/todos', todo)
  //     .map(response => {
  //       return new Todo(response.json());
  //     })
  //     .catch(this.handleError);
  // }

  public updateUser(user: User): Observable<User> {
    return this.http
      .put(API_URL + '/api/user', user)
      .map(response => {
        const userResponse = response.json();
        return new User(userResponse.data);
      })
      .catch(this.handleError);
  }

  public deleteUserById(userId: number): Observable<null> {
    return this.http
      .delete(API_URL + '/api/user/' + userId)
      .map(response => null)
      .catch(this.handleError);
  }

  private handleError (error: Response | any) {
    console.error('ApiService::handleError', error);
    return Observable.throw(error);
  }

}
