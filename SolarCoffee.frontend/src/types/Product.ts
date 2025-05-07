export interface IProduct {
  description: string
  id: number
  isArchived: boolean
  isTaxable: boolean
  name: string
  price: number
  createdOn: string
  updatedOn: string
  quantity?: number
}
