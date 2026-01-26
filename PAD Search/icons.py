import re



file_path = './PADDashFormation/monsters-info/skill_en.json'
# finds all unique {icons} used skill descriptions
# regex = re.compile('{[A-Za-z ]*}')
# file = open("./PADDashFormation/monsters-info/mon_en.json", encoding='utf-8')
# print(file.read(100))
# file.close()

all_list = [re.findall(r'{[0-9%A-Za-z \[\]\+&]*}', line) for line in open(file_path, encoding='utf-8')]
unique_list = list(set(all_list[0]))

sorted_unique_list = sorted(unique_list, key = lambda x: x.count(" "))
print(sorted_unique_list)

c = '0-9%A-Za-z\\[\\]\\+&'

one_word_re = re.compile(f'{{[{c}]*}}')
two_word_re = re.compile(f'{{[{c}]* [{c}]*}}')
three_word_re = re.compile(f'{{[{c}]* [{c}]* [{c}]*}}')

one_word_count = len(list(filter(one_word_re.match, sorted_unique_list)))
two_word_count = len(list(filter(two_word_re.match, sorted_unique_list)))
three_word_count = len(list(filter(three_word_re.match, sorted_unique_list)))
total = len(sorted_unique_list)

print("total:      {0}".format(total))
print("one word:   {0}".format(one_word_count))
print("two word:   {0}".format(two_word_count))
print("three word: {0}".format(three_word_count))
print("rest:       {0}".format(total - one_word_count - two_word_count - three_word_count))
