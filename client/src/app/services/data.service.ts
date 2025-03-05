import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, of, tap } from 'rxjs';
import { Product } from '../models/product';
import { InventoryTransaction } from '../models/inventory';
import moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'http://localhost:5000';
  private http = inject(HttpClient);
  private cachedProducts: Product[] = [];

  getProducts(): Observable<Product[]> {
    if (this.cachedProducts.length > 0) {
      return of(this.cachedProducts);
    }

    return this.http.get<Product[]>(`${this.apiUrl}/products`).pipe(
      tap(products => {
        this.cachedProducts = products;
      })
    );
  }

  updateProduct(id: number, product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/products/${id}`, product).pipe(
      tap(updatedProduct => {
        const index = this.cachedProducts.findIndex(p => p.id === id);
        if (index !== -1) {
          this.cachedProducts[index] = updatedProduct;
        }
      })
    );
  }

  getInventoryTransactions(fromDate: moment.Moment, toDate: moment.Moment): Observable<InventoryTransaction[]> {
    const params = new HttpParams()
      .set('fromDate', fromDate.format('YYYY-MM-DD'))
      .set('toDate', toDate.format('YYYY-MM-DD'));

    return this.http.get<InventoryTransaction[]>(`${this.apiUrl}/inventory-transactions`, { params });
  }
} 