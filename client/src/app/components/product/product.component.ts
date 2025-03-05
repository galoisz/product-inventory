import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss'
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  selectedProduct: Product | null = null;
  productForm: FormGroup;
  
  private dataService = inject(DataService);
  private fb = inject(FormBuilder);

  constructor() {
    this.productForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      category: ['', Validators.required],
      unitPrice: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.dataService.getProducts().subscribe({
      next: (products: Product[]) => {
        this.products = products;
        console.log('Products:', products);
      },
      error: (error) => {
        console.error('Error fetching products:', error);
      }
    });
  }

  onEditClick(product: Product): void {
    this.selectedProduct = { ...product };
    this.productForm.patchValue({
      id: product.id,
      name: product.name,
      category: product.category,
      unitPrice: product.unitPrice
    });
  }

  onSave(): void {
    if (this.productForm.valid && this.selectedProduct) {
      const updatedProduct: Product = this.productForm.value;
      const productId = updatedProduct.id;

      this.dataService.updateProduct(productId, updatedProduct).subscribe({
        next: (response) => {
          console.log('Product updated successfully:', response);
          const index = this.products.findIndex(p => p.id === productId);
          if (index !== -1) {
            this.products[index] = response;
          }
        },
        error: (error) => {
          console.error('Error updating product:', error);
        }
      });
    }
  }
}
