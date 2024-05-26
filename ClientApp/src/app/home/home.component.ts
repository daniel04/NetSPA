import {Component, Inject} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public productoList: Producto[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Producto[]>(baseUrl + 'productos')
      .subscribe(result => {
        this.productoList = result;
      }, error => console.error(error));
  }

}

interface Producto {
  id: number;
  nombre: string;
  precio: number;
  stock: number;
}
