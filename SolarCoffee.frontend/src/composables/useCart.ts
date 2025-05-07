import { ref } from 'vue'
import type { IProduct } from '@/types/Product'

export function useCart() {
    const cart = ref<IProduct[]>([])

    function addToCart(product: IProduct) {
        const existingProduct = cart.value.find(item => item.id === product.id)
        if (existingProduct) {
            existingProduct.quantity += 1
        } else {
            cart.value.push({ ...product, quantity: 1 })
        }
    }

    function removeFromCart(productId: number) {
        const index = cart.value.findIndex(item => item.id === productId)
        if (index !== -1) {
            cart.value.splice(index, 1)
        }
    }

    function clearCart() {
        cart.value = []
    }

    return {
        cart,
        addToCart,
        removeFromCart,
        clearCart
    }
}