import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CobrancasService } from '../../clientes/cobrancas/cobrancas.service';
import { CreatedComponent } from '../created/created.component';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-edit-cobranca',
  templateUrl: './edit-cobranca.component.html',
  styleUrl: './edit-cobranca.component.css'
})
export class EditCobrancaComponent implements OnInit{

  id: any = '';
  descricao: string = '';
  valor: string = '';
  dataVencimento: any = '';
  pago: any = '';
  clienteId: any = '';

  constructor(private dialog: MatDialog, private service: CobrancasService){}

  ngOnInit(): void {
    const cobrancaData = JSON.parse(localStorage.getItem('cobrancaData') || '{}');
    console.log(cobrancaData)
    this.id = cobrancaData.id;
    this.descricao = cobrancaData.descricao;
    this.valor = cobrancaData.valor;
    this.dataVencimento = new Date(cobrancaData.dataVencimento).toISOString().split('T')[0];
    this.pago = cobrancaData.pago;
    this.clienteId = cobrancaData.clienteId;
  }

  updateCobranca(){
    if(this.descricao == null || this.descricao == '' || this.valor == null || this.valor == '' || this.dataVencimento == null || this.dataVencimento == '' || this.pago == null || this.pago == ''){
      alert("campos vazios")
    } else if(this.clienteId == null || this.clienteId == '' ){
      alert("Não encontrado cliente")
    } else {
        this.service.updateCobranca(this.id,this.descricao,this.valor, this.dataVencimento, this.pago, this.clienteId).subscribe(
          (response) => {
            if(response == null){
              alert('Houve um erro ao atualizer cobrança');
            } else {
              this.dialog.open(CreatedComponent)
              window.location.reload();
            }
          }
        )
    }
  }


}
