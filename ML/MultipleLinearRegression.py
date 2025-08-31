import numpy as np
import matplotlib.pyplot as plt

def load_data(path: str):
    data = np.loadtxt(path, delimiter=",")
    X = data[:,:-1]
    y = data[:,-1]
    return X, y

class LinearRegression():
    def __init__(self):
        """ Khoi tao tham so cho mo hinh
            Cac thuoc tinh va tham so khoi tao None thuong la np.ndarray """
        self.weight = None
        self.bias = 0.
        self.learning_rate = 0.1
        self.iterations = 1000
        self.cost_history = []
        self.X_mean = None
        self.X_std = None

    def config_parameters(self, 
                        weight: np.ndarray = None,
                        bias: float = None,
                        learning_rate: float = None,
                        iterations: int = None):
        "Thay doi thong so cua mo hinh"
        if weight: self.weight = weight
        if bias: self.bias = bias
        if learning_rate: self.learning_rate = learning_rate
        if iterations: self.iterations = iterations

    def parameters(self):
        "tra ve cac tham so cua mo hinh"
        return self.weight, self.bias, self.learning_rate, self.iterations, self.cost_history
    
    def fit(self,
            X: np.ndarray = None,
            y: np.ndarray = None):
        "Huan luyen mo hinh dua tren features va targets"
        if (X is None) or (y is None): return
        n_samples, n_features = X.shape
        self.weight = np.zeros(n_features)
        # tinh gia tri trung binh (mean), do lech chuan (std) cua features[j] (tren toan bo sample)
        self.X_mean = X.mean(axis=0)
        self.X_std = X.std(axis=0)
        # chuan hoa features (z-score)
        X_norm = (X - self.X_mean) / self.X_std
        for i in range(self.iterations):
            error = (X_norm.dot(self.weight) + self.bias) - y   # error = f_wb - y
            # tinh gradient
            dw = X_norm.T.dot(error) / n_samples
            db = error.sum() / n_samples
            # cap nhat tham so cho mo hinh
            self.weight = self.weight - self.learning_rate * dw
            self.bias = self.bias - self.learning_rate * db
            # tinh chi phi
            cost = ((error)**2).sum() / (2 * n_samples)
            self.cost_history.append(cost)
            print(f"iteartions: {i:4d}, cost: {cost}")

    def predict(self, x: np.ndarray = None):
        if x is None: return
        x_norm = (x - self.X_mean) / self.X_std     # chuan hoa features x
        return x_norm.dot(self.weight) + self.bias

    def plot_cost_history(self):
        plt.plot(self.iterations, self.cost_history, c="blue")
        plt.title("cc")
        plt.xlabel("iterations")
        plt.ylabel("cost")
        plt.show()

if __name__ == "__main__":
    X_train, y_train = load_data("data/data_MLG.txt")
    model = LinearRegression()
    model.config_parameters(iterations=2000)
    model.fit(X_train, y_train)
    y_pred = model.predict([1200, 3, 1, 40])
    print(f"predict value: {y_pred * 1000 :.0f}$")