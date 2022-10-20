import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCreateBookComponent } from './admin-create-book.component';

describe('AdminCreateBookComponent', () => {
  let component: AdminCreateBookComponent;
  let fixture: ComponentFixture<AdminCreateBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminCreateBookComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCreateBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
