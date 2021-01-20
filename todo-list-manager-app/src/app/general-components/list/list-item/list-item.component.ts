import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent implements OnInit {

  @Input() listItem: any;

  @Input() allowToggle:boolean = true;

  @Input() allowRemove:boolean = true;

  @Input() allowDetails:boolean = true;

  @Output()
  remove: EventEmitter<any> = new EventEmitter();

  @Output()
  toggleDone: EventEmitter<any> = new EventEmitter();

  @Output()
  getDetails:EventEmitter<any> = new EventEmitter();

  @Output()
  save:EventEmitter<any> = new EventEmitter();

  editMode:boolean = false;
  constructor() {
  }
  ngOnInit(): void {
    if(!this.listItem.id || this.listItem.id<=0)
      this.editMode=true;
  }

  toggleTaskDone(task: any) {
    if(this.editMode){
      if(task.state == "done")
        task.state = "todo";
      else
        task.state = "done";
    }
    else
      this.toggleDone.emit(task);
  }

  removeItem(item: any) {
    this.remove.emit(item);
  }

  getItemDetails(item:any){
    this.getDetails.emit(item);
  }

  saveItem(item:any){
    this.editMode = false;
    this.save.emit(item);
  }

}
