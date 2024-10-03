from fastapi import FastAPI
from app.routes import router as inventory_router

app = FastAPI()

# Register the inventory routes
app.include_router(inventory_router, prefix="/inventory", tags=["inventory"])

# Simple root endpoint
@app.get("/")
def read_root():
    return {"message": "Welcome to the Inventory API!"}
