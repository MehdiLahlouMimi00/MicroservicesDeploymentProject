package com.example.product_service.Repository;

import org.springframework.data.jpa.repository.JpaRepository;
import com.example.product_service.Model.Product;

public interface ProductRepository extends JpaRepository<Product, Long> {
    
}

