<template>
  <div>
    <header class="main-header">
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/products">Products</RouterLink>
        <RouterLink to="/about">About</RouterLink>
        <span class="cart-icon" @click="goToCart">
          🛒 <span class="cart-count">{{ cartCount }}</span>
        </span>
      </nav>
    </header>
    <main>
      <slot />
    </main>
  </div>
</template>

<script setup lang="ts">
import { RouterLink, useRouter } from 'vue-router'
import { computed } from 'vue'
import { useCart } from '@/composables/useCart'

const { cart } = useCart()
const cartCount = computed(() => cart.value.reduce((sum, p) => sum + (p.quantity || 1), 0))
// const cartCount = computed(() => cart.value.length)
const router = useRouter()
function goToCart() {
  router.push('/cart')
}
</script>

<style scoped>
.main-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1rem 2rem;
  background: #f8f8f8;
  border-bottom: 1px solid #eee;
}
nav {
  display: flex;
  gap: 1.5rem;
  align-items: center;
}
.cart-icon {
  cursor: pointer;
  font-size: 1.3rem;
  position: relative;
}
.cart-count {
  background: #42b983;
  color: #fff;
  border-radius: 50%;
  padding: 0.2em 0.6em;
  font-size: 0.9rem;
  margin-left: 0.2em;
}
</style>