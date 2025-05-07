<template>
    <div class="products-view">
        <h1>Products</h1>
        <div class="product-list">
        <ProductCard
        :key="idx"
            v-for="product,idx in products"
            :product="product"
        />
        </div>
    </div>
</template>
<script setup lang="ts">
import { onBeforeMount, ref } from 'vue';
import { useRoute } from 'vue-router';
import { useProducts } from '../composables/useProducts';
// import { useToast } from 'vue-toastification';
import ProductCard from '../components/ProductCard.vue';

const route = useRoute();
const { getProducts,products } = useProducts();
onBeforeMount(async () => {
   
        await getProducts();
        console.log('Products:', products.value);
    
});
</script>