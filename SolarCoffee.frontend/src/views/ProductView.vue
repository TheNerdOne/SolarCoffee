<template>
    <div v-if="product" class="product-view">
        <h1>{{ product.name }}</h1>
        <!-- <img :src="product.imageUrl" alt="Product Image" /> -->
        <p>{{ product.description }}</p>
        <p>Price: {{ formatCurrency(product.price) }}</p>
        <button @click="handleAddToCart(product)">Add to Cart</button>
    </div>
</template>
<script setup lang="ts">
import { onBeforeMount, ref } from 'vue';

const formatCurrency = (value: number) => {
    return new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(value);
};
import { useRoute } from 'vue-router';
import { useProducts } from '../composables/useProducts';
import { useCart } from '../composables/useCart';
import type { IProduct } from '@/types/Product';

const route = useRoute();
const { getProductById } = useProducts();
const { addToCart } = useCart();

const product = ref<IProduct | null>(null);
const productId = route.params.productId as string;

 onBeforeMount(async()=>{
    product.value = await getProductById(productId);
 })

function handleAddToCart(product) {
  addToCart(product)
}
</script>