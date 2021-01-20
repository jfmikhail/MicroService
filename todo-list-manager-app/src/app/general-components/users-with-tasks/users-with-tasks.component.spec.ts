import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersWithTasksComponent } from './users-with-tasks.component';

describe('UsersWithTasksComponent', () => {
  let component: UsersWithTasksComponent;
  let fixture: ComponentFixture<UsersWithTasksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsersWithTasksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersWithTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
