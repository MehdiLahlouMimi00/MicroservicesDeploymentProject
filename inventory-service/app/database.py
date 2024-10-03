from motor.motor_asyncio import AsyncIOMotorClient
from bson.objectid import ObjectId

# Database configuration
MONGO_DETAILS = "mongodb://localhost:27017"

client = AsyncIOMotorClient(MONGO_DETAILS)

# Define the database and collection names
database = client.inventory
inventory_collection = database.get_collection("items")

# Helper to convert MongoDB documents into JSON-like format
def item_helper(item) -> dict:
    return {
        "id": str(item["_id"]),
        "name": item["name"],
        "quantity": item["quantity"],
    }
