export interface InventoryTransaction {
    id: number;
    productId: number;
    productName: string;
    date: Date;
    quantity: number;
    transactionType: string;
} 