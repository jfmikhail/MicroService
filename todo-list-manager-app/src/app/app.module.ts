import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { ListComponent } from './general-components/list/list/list.component';
import { ListItemComponent } from './general-components/list/list-item/list-item.component';
import { TaskService } from './tasks/services/task.service';
import { UserService } from './users/services/user.service';
import { AppRoutingModule } from './app-routing.module';

import { NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { UsersWithTasksComponent } from './general-components/users-with-tasks/users-with-tasks.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    ListItemComponent,
    UsersWithTasksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
  providers: [TaskService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
