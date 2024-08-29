import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NotFoundComponent } from '../modal/not-found/not-found.component';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  senha: string = '';
  email: string = '';

  constructor(private service: LoginService, private router: Router, private dialog: MatDialog){
  }

  sendLogin(){
    try{
      this.service.login(this.email, this.senha).subscribe(
        (response) => {
          if(response == null){
            this.dialog.open(NotFoundComponent)
          } else {
            localStorage.setItem('userData', JSON.stringify(response));
            this.router.navigate(['/clientes']);
          }
        },
        (response) => {
          this.dialog.open(NotFoundComponent)
        }
      )
    } catch(e){
    }


  }

}
