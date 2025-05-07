<template>
    <div v-if="product" class="product-card">
        <div class="product-card__content">
            <h2 class="product-card__title">{{ product.name }}</h2>
            <p class="product-card__description">{{ product.description }}</p>
            <p class="product-card__price">${{ product.price.toFixed(2) }}</p>
            <button class="product-card__button">
                <router-link
                    :to="{ name: 'product', params: { productId: product.id } }"
                    class="product-card__button">
                    Details
                </router-link>
            </button>
        </div>
    </div>
</template>
<script setup lang="ts">
import { defineProps } from 'vue';
import type { IProduct } from '@/types/Product';
defineProps<{
  product: IProduct
}>()   

</script>
<style scoped>
.product-card {
    background: white;
    border-radius: 8px;
    box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1);
    transition: transform 0.2s ease, box-shadow 0.2s ease;
    overflow: hidden;
    margin: 1rem;
    width: 300px;
}

.product-card:hover {
    transform: translateY(-4px);
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.15);
}

.product-card__content {
    padding: 1.5rem;
}

.product-card__title {
    color: #2c3e50;
    font-size: 1.25rem;
    font-weight: 600;
    margin: 0 0 0.5rem 0;
}

.product-card__description {
    color: #666;
    font-size: 0.9rem;
    line-height: 1.5;
    margin: 0.5rem 0;
    height: 3em;
    overflow: hidden;
    text-overflow: ellipsis;
}

.product-card__price {
    color: #42b983;
    font-size: 1.5rem;
    font-weight: 700;
    margin: 1rem 0;
}

.product-card__button {
    background: #42b983;
    border: none;
    border-radius: 4px;
    color: white;
    cursor: pointer;
    font-size: 1rem;
    font-weight: 500;
    padding: 0.75rem 1.5rem;
    width: 100%;
    transition: background 0.2s ease;
}

.product-card__button:hover {
    background: #3aa876;
}
</style>