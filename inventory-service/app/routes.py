from fastapi import APIRouter, HTTPException
from typing import List
from app.models import Item
from app.database import inventory_collection, item_helper
from app.schemas import ItemCreate
from bson import ObjectId

router = APIRouter()

# Get all items
@router.get("/items", response_model=List[Item])
async def get_items():
    items = []
    async for item in inventory_collection.find():
        items.append(item_helper(item))
    return items

# Create a new item
@router.post("/items", response_model=Item)
async def create_item(item: ItemCreate):
    new_item = await inventory_collection.insert_one(item.dict())
    created_item = await inventory_collection.find_one({"_id": new_item.inserted_id})
    return item_helper(created_item)

# Get a single item by ID
@router.get("/items/{id}", response_model=Item)
async def get_item(id: str):
    item = await inventory_collection.find_one({"_id": ObjectId(id)})
    if item:
        return item_helper(item)
    raise HTTPException(status_code=404, detail="Item not found")

# Update an item
@router.put("/items/{id}", response_model=Item)
async def update_item(id: str, item: ItemCreate):
    updated_item = await inventory_collection.update_one(
        {"_id": ObjectId(id)}, {"$set": item.dict()}
    )
    if updated_item.modified_count == 1:
        updated_item = await inventory_collection.find_one({"_id": ObjectId(id)})
        return item_helper(updated_item)
    raise HTTPException(status_code=404, detail="Item not found")

# Delete an item
@router.delete("/items/{id}")
async def delete_item(id: str):
    delete_result = await inventory_collection.delete_one({"_id": ObjectId(id)})
    if delete_result.deleted_count == 1:
        return {"message": "Item deleted successfully"}
    raise HTTPException(status_code=404, detail="Item not found")
