import unittest
import gameoflife as gol
import numpy as np


class test_game_of_life(unittest.TestCase):

    def setUp(self):
        gol.grid = np.zeros((3, 3))
        gol.grid[1, 1] = 1

    def test_any_live_cell_with_fewer_than_two_live_neighbors_dies_as_if_by_underpopulation(self):
        # 0|0|0
        # 0|1|0
        # 0|0|0
        result = gol.get_next_living_status(1, 1, gol.grid)
        self.assertEqual(result, 0)

        # 0|1|0
        # 0|1|0
        # 0|0|0
        gol.grid[0, 1] = 1
        result = gol.get_next_living_status(1, 1, gol.grid)
        self.assertEqual(result, 0)

    def test_any_live_cell_with_two_or_three_live_neighbors_lives_on_to_the_next_generation(self):
        # 1|1|0
        # 0|1|0
        # 0|0|0
        gol.grid[0, 0] = 1
        gol.grid[0, 1] = 1
        result = gol.get_next_living_status(1, 1, gol.grid)
        self.assertEqual(result, 1)

        # 1|1|1
        # 0|1|0
        # 0|0|0
        gol.grid[0, 0] = 1
        gol.grid[0, 1] = 1
        gol.grid[0, 2] = 1
        result = gol.get_next_living_status(1, 1, gol.grid)
        self.assertEqual(result, 1)

    def test_any_live_cell_with_more_than_three_live_neighbors_dies_as_if_by_overpopulation(self):
        # 1|1|1
        # 1|1|0
        # 0|0|0
        gol.grid[0, 0] = 1
        gol.grid[0, 1] = 1
        gol.grid[0, 2] = 1
        gol.grid[1, 0] = 1
        result = gol.get_next_living_status(1, 1, gol.grid)
        self.assertEqual(result, 0)

    def test_any_dead_cell_with_exactly_three_live_neighbors_becomes_a_live_cell_as_if_by_reproduction(self):
        # 1|1|1
        # 0|0|0
        # 0|0|0
        gol.grid[0, 0] = 1
        gol.grid[0, 1] = 1
        gol.grid[0, 2] = 1
        gol.grid[1, 1] = 0
        result = gol.get_next_living_status(1, 1, gol.grid)
        self.assertEqual(result, 1)


if __name__ == '__main__':
    unittest.main()
