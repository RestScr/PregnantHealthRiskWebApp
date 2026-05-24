from catboost import CatBoostClassifier
from app.dependencies.config import config


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

            _model.load_model(config.health_risk_classifier_model_path)

        return _model
