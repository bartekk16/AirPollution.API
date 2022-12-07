import pandas as pd
from sklearn.model_selection import train_test_split
import numpy as np
from sklearn.preprocessing import PolynomialFeatures
#df = pd.read_csv(r'C:\Users\1234\Desktop\dane_z_uv.csv')
df = pd.read_csv('dane.csv')
#df = df.drop('uvindex', axis=1)
x = df.drop('PM2.5', axis=1)
y = df['PM2.5']
poly = PolynomialFeatures(degree=2, include_bias=False)
x= poly.fit_transform(x)
X_train, X_test, y_train, y_test = train_test_split(x, y, test_size=0.25)
from sklearn.linear_model import LinearRegression
poly_reg = LinearRegression()
poly_reg.fit(X_train, y_train)
coefs=poly_reg.coef_
interception=poly_reg.intercept_
functionCoeffitiens = np.insert(coefs, 0, interception)
np.savetxt('coefs.csv', functionCoeffitiens, fmt='%s')