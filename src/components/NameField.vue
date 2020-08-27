<template>
  <div>
    name:
    <b-form-input
      v-model="name"
      id="nameInput"
      :style="`color:hsl(${color}, 100%, 50%)`"
    ></b-form-input>
  </div>
</template>

<script>
export default {
  computed: {
    color: function() {
      return this.$store.getters.color;
    },

    name: {
      get() {
        return this.$store.getters.name;
      },
      set(value) {
        this.$store.commit("setName", value);
      }
    }
  }
};
</script>

<style lang="scss">
#nameInput {
  font-weight: bolder;
}
</style>
