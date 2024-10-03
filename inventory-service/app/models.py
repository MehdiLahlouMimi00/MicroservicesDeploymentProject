from pydantic import BaseModel

# Model for MongoDB
class Item(BaseModel):
    name: str
    quantity: int
