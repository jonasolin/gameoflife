import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import random
from settings import Settings


def create_starting_grid():
    grid = np.zeros(Settings.size)
    startingCells = set_random_start_values()
    grid[Settings.grid_offset[0]:Settings.grid_offset[0] + startingCells.shape[0],
         Settings.grid_offset[1]:Settings.grid_offset[1] + startingCells.shape[1]] = startingCells
    return grid


def set_random_start_values():
    cells = np.zeros((30, 30))
    for i in range(cells.shape[0]):
        for j in range(cells.shape[1]):
            cells[i, j] = random.randint(0, 1)
    return cells


def get_living_neighbors(x, y, grid):
    return np.sum(grid[x-1:x+2, y-1:y+2]) - grid[x, y]


def get_next_living_status(x, y, grid):
    result = get_living_neighbors(x, y, grid)
    if result == 2:
        return grid[x, y]
    if result == 3:
        return 1
    return 0


def update_life(grid):
    next_generation_cells = np.copy(grid)
    for i in range(grid.shape[0]):
        for j in range(grid.shape[1]):
            next_generation_cells[i, j] = get_next_living_status(i, j, grid)
    return next_generation_cells


def animate(grid):
    fig = plt.figure(dpi=Settings.quality)
    plt.axis(Settings.plt_axis)
    ims = []
    for _ in range(Settings.iterations):
        ims.append((plt.imshow(grid, cmap=Settings.color_map),))
        grid = update_life(grid)
    _ = animation.ArtistAnimation(
        fig, ims, interval=Settings.interval, repeat_delay=Settings.repeat_delay, blit=True
    )
    plt.show()


def live():
    grid = create_starting_grid()
    animate(grid)
