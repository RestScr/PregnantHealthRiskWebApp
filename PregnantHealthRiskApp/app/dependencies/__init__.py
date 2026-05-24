"""
    Файл инициализации главного роутера
    для API.
"""

from fastapi import APIRouter
from routes import home
from routes import model_request

main_router = APIRouter()

main_router.include_router(home.router, tags=["Homepage"])
main_router.include_router(model_request.router, tags=["Model Request"])
