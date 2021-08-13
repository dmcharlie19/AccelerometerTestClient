import numpy as np
import matplotlib.pyplot as plt

# file = input()
# print(file)

data = np.loadtxt('D:\WorkSpace3\Kordis50\Soft\Hal\Test\\vibrationTester\Kordis50ProductTestParser_WinForm\\bin\Debug\Logs\\2g_disable_BW0_11_16_3.log')
# data = np.loadtxt(file);
plt.plot(data)
plt.grid()
plt.show()
