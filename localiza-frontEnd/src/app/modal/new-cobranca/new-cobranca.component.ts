import { Component } from '@angular/core';
import { CreatedComponent } from '../created/created.component';
import { MatDialog } from '@angular/material/dialog';
import { CobrancasService } from '../../clientes/cobrancas/cobrancas.service';

@Component({
  selector: 'app-new-cobranca',
  templateUrl: './new-cobranca.component.html',
  styleUrl: './new-cobranca.component.css'
})
export class NewCobrancaComponent {

  descricao: string = '';
  valor: string = '';
  dataVencimento: any = '';
  pago: any = '';
  clienteId: any = '';

  constructor(private dialog: MatDialog, private service: CobrancasService){}


  cadastrarCobranca(){
    const clienteData = JSON.parse(localStorage.getItem('clienteData') || '{}');
    this.clienteId = clienteData.id;
    if(this.descricao == null || this.descricao == '' || this.valor == null || this.valor == '' || this.dataVencimento == null || this.dataVencimento == '' || this.pago == null || this.pago == ''){
      alert("campos vazios")
    } else if(clienteData == null || clienteData == '' ){
      alert("nao logado")
    } else {
        this.service.cadastrarCobranca(this.descricao,this.valor, this.dataVencimento, this.pago, this.clienteId).subscribe(
          (response) => {
            if(response == null){
              alert('Houve um erro ao cadastrar novo usuário');
            } else {
              this.dialog.open(CreatedComponent)
              window.location.reload();
            }
          }
        )
    }
  }

}
