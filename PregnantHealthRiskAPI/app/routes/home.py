"""
    Путь домашней страницы API.
"""

from fastapi import APIRouter
from app.model.status_data.status_data import StatusData

router = APIRouter()


@router.get("/",
            summary="Домашняя страница")
def home():
    statusData = {
        "Success": True,
        "Message": "Welcome to the HealthRiskClassifier page."
    }
    return StatusData(**statusData)

