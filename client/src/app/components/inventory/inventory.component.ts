import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { InventoryTransaction } from '../../models/inventory';
import { DataService } from '../../services/data.service';
import moment from 'moment';

@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.scss'
})
export class InventoryComponent implements OnInit {
  private dataService = inject(DataService);
  private fb = inject(FormBuilder);
  
  filterForm: FormGroup;
  transactions: InventoryTransaction[] = [];

  constructor() {
    this.filterForm = this.fb.group({
      fromDate: [moment().startOf('year').format('YYYY-MM-DD'), Validators.required],
      toDate: [moment().endOf('year').format('YYYY-MM-DD'), Validators.required]
    });
  }

  ngOnInit(): void {
    this.searchTransactions();
  }

  searchTransactions(): void {
    if (this.filterForm.valid) {
      const fromDate = moment(this.filterForm.get('fromDate')?.value);
      const toDate = moment(this.filterForm.get('toDate')?.value);

      this.dataService.getInventoryTransactions(fromDate, toDate).subscribe({
        next: (transactions: InventoryTransaction[]) => {
          this.transactions = transactions;
          console.log('Inventory Transactions:', transactions);
        },
        error: (error) => {
          console.error('Error fetching inventory transactions:', error);
        }
      });
    }
  }
}
