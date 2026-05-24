from pydantic import BaseModel, ConfigDict

class StatusData(BaseModel):
    """
        Базовый класс информации запроса.
    """
    Success: bool
    Message: str

    model_config = ConfigDict(
        extra="forbid"
    )
