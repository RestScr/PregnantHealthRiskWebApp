from app.model.status_data.status_data import StatusData
from pydantic import ConfigDict


class StatusDataWithContent(StatusData):
    """
        Класс на случай, если вместе со статусом необходимо передать
        какие-либо данные.
    """
    Content : object

    model_config = ConfigDict(
        extra="forbid"
    )
