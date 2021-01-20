import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { UsersWithTasksComponent } from './general-components/users-with-tasks/users-with-tasks.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'todos',
    pathMatch: 'full'
  },
  {
    path: 'todos',
    component: UsersWithTasksComponent,
  },
//   {
//     path: '**',
//     component: PageNotFoundComponent
//   }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [  ]
})
export class AppRoutingModule {
}
