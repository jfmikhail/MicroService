import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Task } from '../../../tasks/models/task';
import { User } from '../../../users/models/user';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  @Input()
  listItems: any[];

  @Input()
  allowToggle:boolean = true;

  @Input()
  allowRemove:boolean = true;

  @Input()
  allowDetails:boolean =true;

  @Output()
  getDetails:EventEmitter<any> = new EventEmitter();

  @Output()
  remove: EventEmitter<any> = new EventEmitter();

  @Output()
  toggleDone: EventEmitter<any> = new EventEmitter();

  @Output()
  save: EventEmitter<any> = new EventEmitter();

  constructor() {
  }
  ngOnInit(): void {
  }

  onToggleTaskDone(task: Task) {
    if(!this.allowToggle)
      return;
    this.toggleDone.emit(task);
  }

  onRemove(user: User) {
    if(!this.allowRemove)
      return;
    this.remove.emit(user);
  }

  getItemDetails(user:User){
    if(!this.allowDetails)
      return;
    this.getDetails.emit(user);
  }

  saveItem(item:any){
    this.save.emit(item);
  }

}
