import os
import datetime

def add_datetime_suffix(basename: str, delimiter: str = '_') -> str:
    """ basename에 datetime 접미사를 붙임. (e.g. basename_220622_140322) """
    suffix = datetime.datetime.now().strftime("%y%m%d_%H%M%S")
    return delimiter.join([basename, suffix])

def create_dir(directory):
    """ directory가 존재하지 않으면 생성함. """
    try:
        if not os.path.exists(directory):
            os.makedirs(directory)
    except OSError:
        print("Error: Failed to create the directory.")
        