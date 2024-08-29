import { Component } from '@angular/core';
import { CadastroService } from './cadastro.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { CreatedComponent } from '../modal/created/created.component';

@Component({
  selector: 'cadastro',
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {


  nome: string = '';
  senha: string = '';
  email: string = '';

  constructor(private service: CadastroService, private router: Router, private dialog: MatDialog) {}

  sendCadastro(){
    if(this.nome == null || this.nome == '' || this.email == null || this.email == '' || this.senha == null || this.email == ''){
      alert("campos vazios")
    } else {
        this.service.cadastrar(this.nome,this.email, this.senha).subscribe(
          (response) => {
            if(response == null){
              alert('Houve um erro ao cadastrar novo usuário');
            } else {
              this.dialog.open(CreatedComponent)
              this.router.navigate(['/']);
            }
          }
        )

    }
  }

}
