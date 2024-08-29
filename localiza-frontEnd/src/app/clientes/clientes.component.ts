import { ClientesService } from './clientes.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NewClientComponent } from '../modal/new-client/new-client.component';
import { MatDialog } from '@angular/material/dialog';
import { EditClientComponent } from '../modal/edit-client/edit-client.component';
import { DeleteSucessComponent } from '../modal/delete-sucess/delete-sucess.component';
import { NotFoundComponent } from '../modal/not-found/not-found.component';

@Component({
  selector: 'clientes',
  templateUrl: './clientes.component.html',
  styleUrl: './clientes.component.css'
})
export class ClientesComponent implements OnInit{
  clientes: any

  constructor(private router: Router, private service: ClientesService, private dialog: MatDialog){}

  ngOnInit(){
    this.callClientes()
  }

  callClientes(){
    const userData = JSON.parse(localStorage.getItem('userData') || '{}');
    if(userData != null){
      this.service.showClientes(userData.id).subscribe(
        (response) => {
          this.clientes = response
        }
      )
    }
  }

  cadastrarNovo(){
    this.dialog.open(NewClientComponent)
  }
  updateCliente(updateCliente: any){
    localStorage.setItem('clienteData', JSON.stringify(updateCliente));
    this.dialog.open(EditClientComponent)
  }

  goToCobranca(cliente: any) {
    localStorage.setItem('clienteData', JSON.stringify(cliente));
    this.router.navigate(['/cobrancas'])
  }

  deleteCliente(id: any){
    this.service.deleteCliente(id).subscribe(
      (response) => {
        if(response = true){
          this.dialog.open(DeleteSucessComponent)
        } else {
          this.dialog.open(NotFoundComponent)
        }
      }
    )
    window.location.reload();
  }


}
