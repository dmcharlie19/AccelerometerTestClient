import numpy as np
import matplotlib.pyplot as plt


data = np.loadtxt('D:\WorkSpace3\Kordis50\Soft\Hal\Test\\vibrationTester\Kordis50ProductTestParser_WinForm\\bin\Debug\py\\logFile.txt')
plt.plot(data)
plt.grid()
plt.show()
