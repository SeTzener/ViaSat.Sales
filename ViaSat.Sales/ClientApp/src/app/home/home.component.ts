import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public goods: Good[];
  public goodsTotal: number = 0;
  public taxTotal: number = 0;
  private basePath: string = "";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.basePath = baseUrl;
    http.get<Good[]>(baseUrl + 'home').subscribe(result => {
      this.goods = result;
      result.forEach(a => this.taxTotal += a.tax);
      result.forEach(a => this.goodsTotal += a.total);
      this.goodsTotal = +this.goodsTotal.toFixed(2);
      this.taxTotal = +this.taxTotal.toFixed(2);
    }, error => console.error(error));

  }

  public loadList() {
    location.reload()
  };
}



interface Good {
  quantity: number;
  name: string;
  isImported: boolean;
  isExempt: boolean;
  tax: number;
  total: number;
}
