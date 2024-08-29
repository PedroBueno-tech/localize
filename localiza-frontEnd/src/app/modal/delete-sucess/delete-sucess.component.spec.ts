import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteSucessComponent } from './delete-sucess.component';

describe('DeleteSucessComponent', () => {
  let component: DeleteSucessComponent;
  let fixture: ComponentFixture<DeleteSucessComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteSucessComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteSucessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
