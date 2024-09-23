const express = require('express');
const { createProxyMiddleware } = require('http-proxy-middleware');
require('dotenv').config();

const app = express();

// Spring API  3000
app.use('/products', createProxyMiddleware({
  target: process.env.PRODUCT_SERVICE_URL,
  changeOrigin: true,
}));

// .NET API  3001
app.use('/orders', createProxyMiddleware({
  target: process.env.ORDER_SERVICE_URL,
  changeOrigin: true,
}));

// Python api   3002
app.use('/customers', createProxyMiddleware({
  target: process.env.CUSTOMER_SERVICE_URL,
  changeOrigin: true,
}));

const PORT = process.env.PORT || 5000;
app.listen(PORT, () => {
  console.log(`API Gateway running on port ${PORT}`);
});
