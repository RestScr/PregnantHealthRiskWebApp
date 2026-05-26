"""
    Файл инициализации главного роутера
    для API.
"""
from fastapi import APIRouter

from PregnantHealthRiskApi.app.routes import home
from PregnantHealthRiskApi.app.routes import model_request
from PregnantHealthRiskApi.app.routes import model_get_prediction

main_router = APIRouter()

main_router.include_router(home.router, tags=["Homepage"])
main_router.include_router(model_request.router, tags=["Model Request"])
main_router.include_router(model_get_prediction.router, tags=["Model Get Prediction"])
