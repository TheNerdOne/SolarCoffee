import { ref } from 'vue'
import type { IProduct } from '@/types/Product'

const cart = ref<IProduct[]>([])
export function useCart() {
  function addToCart(product: IProduct) {
    const existingProduct = cart.value.find((item) => item.id === product.id)
    if (existingProduct) {
      existingProduct.quantity += 1
    } else {
      cart.value.push({ ...product, quantity: 1 })
      console.log(cart.value)
    }
  }

  function removeFromCart(productId: number) {
    const index = cart.value.findIndex((item) => item.id === productId)
    if (index !== -1) {
      cart.value.splice(index, 1)
    }
  }

  function clearCart() {
    cart.value = []
  }

  function updateQuantity(productId: number, quantity: number) {
    const product = cart.value.find((item) => item.id === productId)
    if (product) {
      product.quantity = quantity
    }
  }

  return {
    cart,
    addToCart,
    removeFromCart,
    clearCart,
    updateQuantity
  }
}
