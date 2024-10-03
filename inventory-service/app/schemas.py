from pydantic import BaseModel

# Schema for the request body
class ItemCreate(BaseModel):
    name: str
    quantity: int
