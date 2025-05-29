<template>
    <div class="cart-container">
      <h1>Your Cart</h1>
      <div v-if="cart.length === 0" class="empty-cart">
        <p>Your cart is empty.</p>
        <RouterLink to="/products" class="shop-link">Go Shopping</RouterLink>
      </div>
      <div v-else>
        <table class="cart-table">
          <thead>
            <tr>
              <th>Product</th>
              <th>Unit Price</th>
              <th>Quantity</th>
              <th>Subtotal</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in cart" :key="item.id">
              <td>
                <div class="product-info">
                  <!-- <img :src="item.image" alt="" class="product-img" v-if="item.image" /> -->
                  <div>
                    <strong>{{ item.name }}</strong>
                    <p class="desc">{{ item.description }}</p>
                  </div>
                </div>
              </td>
              <td>{{ formatPrice(item.price) }}</td>
              <td>
                <button @click="decrease(item)">-</button>
                <span>{{ item.quantity }}</span>
                <button @click="increase(item)">+</button>
              </td>
              <td>{{ formatPrice(item.price * item.quantity) }}</td>
              <td>
                <button class="remove-btn" @click="remove(item)">Remove</button>
              </td>
            </tr>
          </tbody>
        </table>
        <div class="cart-summary">
          <span>Total:</span>
          <span class="total">{{ formatPrice(total) }}</span>
        </div>
        <button class="checkout-btn">Checkout</button>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  import { computed } from 'vue'
  import { useCart } from '@/composables/useCart'
  
  const { cart, addToCart, removeFromCart, updateQuantity } = useCart()
  
  const total = computed(() =>
    cart.value.reduce((sum, item) => sum + item.price * item.quantity, 0)
  )
  
  function increase(item) {
    updateQuantity(item.id, item.quantity + 1)
  }
  function decrease(item) {
    if (item.quantity > 1) {
      updateQuantity(item.id, item.quantity - 1)
    }
  }
  function remove(item) {
    removeFromCart(item.id)
  }
  function formatPrice(val) {
    return '$' + val.toFixed(2)
  }
  </script>
  
  <style scoped>
  .cart-container {
    max-width: 800px;
    margin: 2rem auto;
    background: #fff;
    padding: 2rem;
    border-radius: 12px;
    box-shadow: 0 2px 8px #0001;
  }
  .cart-table {
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 1.5rem;
  }
  .cart-table th, .cart-table td {
    padding: 0.75rem;
    text-align: left;
    border-bottom: 1px solid #eee;
  }
  .product-info {
    display: flex;
    align-items: center;
    gap: 1rem;
  }
  .product-img {
    width: 60px;
    height: 60px;
    object-fit: cover;
    border-radius: 8px;
    border: 1px solid #eee;
  }
  .desc {
    color: #888;
    font-size: 0.95em;
  }
  button {
    background: #42b983;
    color: #fff;
    border: none;
    padding: 0.3em 0.7em;
    border-radius: 4px;
    cursor: pointer;
    margin: 0 0.2em;
  }
  button:active {
    background: #369870;
  }
  .remove-btn {
    background: #e74c3c;
  }
  .cart-summary {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    font-size: 1.2em;
    margin-bottom: 1.5rem;
    gap: 1em;
  }
  .total {
    font-weight: bold;
    color: #42b983;
  }
  .checkout-btn {
    float: right;
    background: #2d8cf0;
    padding: 0.7em 2em;
    font-size: 1.1em;
  }
  .empty-cart {
    text-align: center;
    color: #888;
  }
  .shop-link {
    display: inline-block;
    margin-top: 1em;
    color: #42b983;
    text-decoration: underline;
  }
  </style>