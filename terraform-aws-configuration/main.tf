resource "aws_ecr_repository" "orders_repo" {
  name = "orders-api"
}

resource "aws_ecr_repository" "inventory_repo" {
  name = "inventory-api"
}

resource "aws_ecr_repository" "product_repo" {
  name = "product-api"
}

resource "aws_ecr_repository" "gateway_repo" {
  name = "gateway-api"
}
