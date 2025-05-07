import { ref } from 'vue'
import type { IProduct } from '@/types/Product'
import { makeRequest } from '@/services/api'

export function useProducts() {
    const products = ref<IProduct[]>([])
    const loading = ref(false)
    const error = ref<string | null>(null)

    const getProducts = async () => {
      loading.value = true
      error.value = null
      try {
        const response = await makeRequest<IProduct[]>('GET', 'api/product')
        products.value = response
      } catch (e) {
        error.value = e instanceof Error ? e.message : 'Failed to fetch products'
      } finally {
        loading.value = false
      }
    }

    const addProduct = async (product: IProduct) => {
        loading.value = true
        error.value = null
        try {
            const response = await makeRequest<IProduct>('POST', 'api/product', product)
            products.value.push(response)
            return response
        } catch (e) {
            error.value = e instanceof Error ? e.message : 'Failed to add product'
            throw error.value
        } finally {
            loading.value = false
        }
    }

    const updateProduct = async (product: IProduct) => {
        loading.value = true
        error.value = null
        try {
            const response = await makeRequest<IProduct>('PUT', `api/product/${product.id}`, product)
            const index = products.value.findIndex(p => p.id === product.id)
            if (index !== -1) {
                products.value[index] = response
            }
            return response
        } catch (e) {
            error.value = e instanceof Error ? e.message : 'Failed to update product'
            throw error.value
        } finally {
            loading.value = false
        }
    }

    const getProductById = async (id: string) => {
        loading.value = true
        error.value = null
        try {
            const response = await makeRequest<IProduct>('GET', `api/product/?id=${id}`)
            return response
        } catch (e) {
            error.value = e instanceof Error ? e.message : 'Failed to fetch product'
            throw error.value
        } finally {
            loading.value = false
        }
    }

    return {
      products,
      loading,
      error,
      getProducts,
      addProduct,
      updateProduct,
      getProductById
    }
}