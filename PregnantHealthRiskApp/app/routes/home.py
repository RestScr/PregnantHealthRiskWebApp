"""
    Путь домашней страницы API.
"""

from fastapi import APIRouter

router = APIRouter()

@router.get("/")
def home():
    statusData = {
        "success": True,
        "message":
            """
            Welcome to the HealtRiskClassifier page.
            """
    }
    return statusData

