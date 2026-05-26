from catboost import CatBoostClassifier
from PregnantHealthRiskApi.app.ai_models.ai_dependencies import config
from pathlib import Path


class HealthRiskClassifier:
    """
    Класс Singleton модели предсказания риска здоровья беременной.
    """
    _model = None

    @staticmethod
    def Instance() -> CatBoostClassifier:
        """
        Получение экземпляра модели.
        :return:
        """
        _model = HealthRiskClassifier._model

        if HealthRiskClassifier._model is None:
            _model = CatBoostClassifier()
            print("Loading model...")
            path = Path(__file__).resolve().parent / config["health_risk_classifier_model_filename"]
            _model.load_model(path)
            print("Model loaded.")
        return _model
